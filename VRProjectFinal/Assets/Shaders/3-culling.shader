Shader "Culling" {

    SubShader {
        Pass {
            //Cull Back
            //Cull Off
            Cull Front


            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag


            struct vertOutput
            {
                float4 pos : SV_POSITION;
                float4 objectPosition : TEXCOORD0;
            };

            vertOutput vert(float4 vertexPos: POSITION) {
                vertOutput output;
                output.pos = UnityObjectToClipPos(vertexPos);
                output.objectPosition = vertexPos;
                return output;
                // all lines computed for each vertex at the same time
            }

            float4 frag(vertOutput input) : COLOR {
                if(input.objectPosition.y > 0)
                {
                    discard;
                }
                return float4(1,0,0,1);
            }

            ENDCG

        }

        Pass {
            //Cull Back
            //Cull Off
            Cull Back


            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag


            struct vertOutput
            {
                float4 pos : SV_POSITION;
                float4 objectPosition : TEXCOORD0;
            };

            vertOutput vert(float4 vertexPos: POSITION) {
                vertOutput output;
                output.pos = UnityObjectToClipPos(vertexPos);
                output.objectPosition = vertexPos;
                return output;
                // all lines computed for each vertex at the same time
            }

            float4 frag(vertOutput input) : COLOR {
                if(input.objectPosition.y > 0)
                {
                    discard;
                }
                return float4(0,0,1,1);
            }

            ENDCG

        }
    }
}