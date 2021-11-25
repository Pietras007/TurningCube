#version 330

struct Material {
    sampler2D diffuse;
    sampler2D specular;
    sampler2D noise;
    float     shininess;
};


struct Light {
    vec3 position;
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};

uniform Light light;
uniform Material material;
uniform vec3 viewPos;

uniform int transparent;

in vec3 FragPos;
in vec3 Normal;
in vec2 TexCoords;

void main()
{
    vec4 materialColor  = vec4(255,255,0,0.8f);

    if(transparent != 0)
    {    
        vec4 transparency = texture(material.noise, TexCoords);
        if((transparency.r + transparency.g + transparency.b) / 3.0f <0.0f)
        {
            discard;
        }

        materialColor = texture(material.diffuse, TexCoords);
    }

    //Ambient
    vec3 lightPos = light.position;
    vec3 ambient = light.ambient * vec3(materialColor);

    // Diffuse 
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(lightPos - FragPos);
    float diff = max(dot(norm, lightDir), 0.0);
    vec3 diffuse = light.diffuse * diff * vec3(materialColor);

    // Specular
    vec3 viewDir = normalize(viewPos - FragPos);
    vec3 reflectDir = reflect(-lightDir, norm);
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
    vec3 specular = light.specular * spec * vec3(texture(material.specular, TexCoords));

    vec3 result = ambient + diffuse + specular;
    vec4 resultColor = vec4(result, 1.0f);
    gl_FragColor = resultColor;
}
