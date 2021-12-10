Shader "Vertex to Fragment" {
    SubShader {
        Pass {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            struct vertOutput
            {
                float4 pos : SV_POSITION;
                float4 col : TEXCOORD0;
            };

            vertOutput vert(float4 vertexPos: POSITION) {
                vertOutput output;
                output.pos = UnityObjectToClipPos(vertexPos);
                output.col = vertexPos + float4(0.5, 0.5, 0.5, 0);
                // each corner of the cube is a vertex and gets a color assigned
                // renders everything inbetween as an interpolated value
                // cube dimensions are -.5,-.5,-.5 out to .5,.5,.5
                // we add .5 to get the colors in the range of 0 to 1
                // still compiles without that and unity clips negative numbers to 0
                return output;
            }

            float4 frag(vertOutput input) : COLOR {
                return input.col;
            }

            ENDCG

        }
    }
}