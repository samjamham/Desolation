Shader "Custom/UnlitClipTerrain"
{
    Properties
    {
        [MainColor] _BaseColor("Base Color", Color) = (1, 1, 1, 1)
        [MainTexture] _BaseMap("Base Map", 2D) = "white" {}
        [DisplacementTexture] _BaseDisplacement("Base Dispalcement", 2D) ="white" {}

    }

    SubShader
    {
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalPipeline" "Queue"="Geometry-2" "TerrainCompatible" = "True"}
        Pass
        {
            //cull off
            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            float4 _Planes[6];

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 MyPos : TEST;
            };

            TEXTURE2D(_BaseMap);
            SAMPLER(sampler_BaseMap);

            sampler2D _BaseDisplacement;

            CBUFFER_START(UnityPerMaterial)
                half4 _BaseColor;
                float4 _BaseMap_ST;
                half4 _BaseDisplacement_ST;
            CBUFFER_END

            Varyings vert(Attributes IN)
            {
                Varyings OUT;
                
                OUT.uv = TRANSFORM_TEX(IN.uv, _BaseMap);

                float xMod = tex2Dlod(_BaseDisplacement, float4(OUT.uv.xy,0,1)).x;
                float3 VertDis = IN.positionOS.xyz;
                VertDis.y += xMod;


                OUT.positionHCS = TransformObjectToHClip(VertDis);
                OUT.MyPos = TransformObjectToWorld(IN.positionOS.xyz);
                return OUT;
            }

            half4 frag(Varyings IN) : SV_Target
            {
                [unroll]
                for (int i = 0; i < 6; i++)
                {
                    float distance = dot(IN.MyPos, _Planes[i].xyz);
                    distance = distance + _Planes[i].w;
                    //discard surface above plane
                    clip(-distance);
                }
                half4 color = SAMPLE_TEXTURE2D(_BaseMap, sampler_BaseMap, IN.uv) * _BaseColor;
                return color;
            }
            ENDHLSL
        }
    }
}
