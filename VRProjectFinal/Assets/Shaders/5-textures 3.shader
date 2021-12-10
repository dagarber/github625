Shader "Textures" {

    Properties {
        _MainTexture ("Image", 2D) = "white" {}

    }

    SubShader {

        Pass {

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            uniform sampler2D _MainTexture;

            struct vertInput
            {
                float4 vertex : POSITION;
                float4 texcoord : TEXCOORD0;
            };

            struct vertOutput
            {
                float4 pos : SV_POSITION;
                float4 tex : TEXCOORD0;
            };

            vertOutput vert(vertInput input) {
                vertOutput output;
                output.pos = UnityObjectToClipPos(input.vertex);
                output.tex = input.texcoord;
                return output;
                // all lines computed for each vertex at the same time
            }

            float4 frag(vertOutput input) : COLOR {
                return tex2D(_MainTexture, input.tex.xy);
            }

            ENDCG

        }
    }
}