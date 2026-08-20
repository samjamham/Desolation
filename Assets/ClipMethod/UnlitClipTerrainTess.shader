Shader "Custom/UnlitClipTerrainTess"
{
    Properties
    {
        _BaseColor("Base Color", Color) = (1, 1, 1, 1)
        _BaseTexture("Base Texture", 2D) = "white" {}
        _TessellationAmount("Tessellation Amount", Range(1.0, 64.0)) = 1.0
        _ZoomScale("Zoom Scale", Range(0,10)) = 1.0
        [DisplacementTexture] _BaseDisplacement("Base Dispalcement", 2D) ="white" {}
    }
    SubShader
    {
        Tags
        {
            "RenderPipeline" = "UniversalPipeline"
            "RenderType" = "Transparent"
            "Queue" = "Transparent"
        }

        Pass
        {

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma hull hull
            #pragma domain domain

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"


            float4 _Planes[6];
            float _Zoomies =1;

            CBUFFER_START(UnityPerMaterial)
                float4 _BaseColor;
                float4 _BaseTexture_ST;
                float _TessellationAmount;
                float _ZoomScale;
                float4 _BaseDisplacement_ST;
            CBUFFER_END

            TEXTURE2D(_BaseTexture);
            SAMPLER(sampler_BaseTexture);

            sampler2D _BaseDisplacement;

            struct appdata
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct tessControlPoint
            {
                float3 positionWS : INTERNALTESSPOS;
                float2 uv : TEXCOORD0;
            };

            struct tessFactors
            {
                float edge[3] : SV_TessFactor;
                float inside  : SV_InsideTessFactor;
            };

            struct t2f
            {
                float4 positionCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 MyPos : TEST;
            };

            tessControlPoint vert(appdata v)
            {
                tessControlPoint o = (tessControlPoint)0;

                o.positionWS = TransformObjectToWorld(v.positionOS.xyz);
                o.uv = TRANSFORM_TEX(v.uv, _BaseTexture);

                return o;
            }

            [domain("tri")]
            [outputcontrolpoints(3)]
            [outputtopology("triangle_cw")]
            [partitioning("integer")]
            [patchconstantfunc("patchConstantFunc")]
            tessControlPoint hull(InputPatch<tessControlPoint, 3> patch, uint id : SV_OutputControlPointID)
            {
                return patch[id];
            }

            tessFactors patchConstantFunc(InputPatch<tessControlPoint, 3> patch)
            {
                //TODO: Tesselate based on the world pos of the vertex
                tessFactors f = (tessFactors)0;

                //f.edge[0] = f.edge[1] = f.edge[2] = f.inside = _TessellationAmount;
                float3 triPos0 = patch[0].positionWS;
                float3 triPos1 = patch[1].positionWS;
                float3 triPos2 = patch[2].positionWS;

                float3 edgePos0 = 0.5f * (triPos1 + triPos2);
                float3 edgePos1 = 0.5f * (triPos0 + triPos2);
                float3 edgePos2 = 0.5f * (triPos0 + triPos1);

                float3 TablePos = float3(0.0f, 0.675f, 0.0f);

                float dist0 = distance(edgePos0, TablePos);
                float dist1 = distance(edgePos1, TablePos);
                float dist2 = distance(edgePos2, TablePos);

                float edgeFactor0 = saturate(1.0f - (dist0 - 1));
                float edgeFactor1 = saturate(1.0f - (dist1 - 1));
                float edgeFactor2 = saturate(1.0f - (dist2 - 1));

                f.edge[0] = max(edgeFactor0 * _TessellationAmount, 1);
                f.edge[1] = max(edgeFactor1 * _TessellationAmount, 1);
                f.edge[2] = max(edgeFactor2 * _TessellationAmount, 1);

                f.inside = (f.edge[0] + f.edge[1] + f.edge[2]) / 3.0f;


                return f;
            }

            [domain("tri")]
            t2f domain(tessFactors factors, OutputPatch<tessControlPoint, 3> patch, float3 barycentricCoordinates : SV_DomainLocation)
            {
                t2f i = (t2f)0;

                float3 positionWS = patch[0].positionWS * barycentricCoordinates.x +
                                    patch[1].positionWS * barycentricCoordinates.y +
                                    patch[2].positionWS * barycentricCoordinates.z;

                float2 uv = patch[0].uv * barycentricCoordinates.x +
                            patch[1].uv * barycentricCoordinates.y +
                            patch[2].uv * barycentricCoordinates.z;
                
                float2 Tiles = _BaseDisplacement_ST.xy;           
                float yMod = tex2Dlod(_BaseDisplacement, float4((uv.xy/Tiles),0,1)).x;
                yMod *= _Zoomies;
                positionWS.y += yMod;

                i.MyPos = positionWS;
                i.positionCS = TransformWorldToHClip(positionWS);
                i.uv = uv;

                return i;
            }

            float4 frag(t2f IN) : SV_TARGET
            {
                [unroll]
                for (int i = 0; i < 6; i++)
                {
                    float distance = dot(IN.MyPos, _Planes[i].xyz);
                    distance = distance + _Planes[i].w;
                    //discard surface above plane
                    clip(-distance);
                }
                float4 textureColor = SAMPLE_TEXTURE2D(_BaseTexture, sampler_BaseTexture, IN.uv);
                return textureColor * _BaseColor;
            }

            ENDHLSL
        }
    }
}