# How to setup textures

Make a folder and name it like you want the vmt to be named:

![help1](https://cdn.discordapp.com/attachments/1137688979743981648/1137699742458056754/image.png)

In that folder you're going to place a few textures:

- albedo (**_rgb**)
- normal (**_n**)
- roughness/gloss (**_r**/**_g**)
- metalness (**_m** or **_alpha**)
- ambient occlusion (**_o** or **_ao**)

![help2](https://cdn.discordapp.com/attachments/1137688979743981648/1137690447884603482/image.png)

**Remember to rename the images by adding the texture type at the end of their names (refer to list above).**

After that, you can press the Open Folders button and select your folder.

# Envmaps

Tool comes with a few envmaps that it uses to generate accurate roughness.  
By default it generates an envmap texture for every vmt, but if you want you can specify a folder for shared usage (make sure it's inside your game's materials folder).

![help3](https://cdn.discordapp.com/attachments/1137688979743981648/1137695819244511252/image.png)

You can find the textures needed for this to work in the envmaps folder of the tool.

![help4](https://cdn.discordapp.com/attachments/1137688979743981648/1137695457137664110/image.png)

**Do not change the names!**

# Batch

If you have a group of folders you can select the root folder instead when pressing the Open Folders button.

![help5](https://cdn.discordapp.com/attachments/1137688979743981648/1137700302947102720/image.png)

![help6](https://cdn.discordapp.com/attachments/1137688979743981648/1137700568886947970/image.png)

If you need, you can also let it create the same folders it found while generating in the output destination.

![help7](https://cdn.discordapp.com/attachments/1137688979743981648/1137701639189434368/image.png)

![help8](https://cdn.discordapp.com/attachments/1137688979743981648/1137702458978742312/image.png)


# FAQ

> Which textures are required?

All of the textures are optional. The tool will work with whatever it finds in the textures folder.


> Tool won't load my textures. What's going on?

Make sure the textures' file type is natively supported by Windows (png, jpg, etc)


> I don't have a glossiness mask. Can I use roughness?

Yes, the tool will invert your roughness texture automatically. Just make sure your file ends with **_r**.


> Can I use a specular map instead of metalness?

No.


> Can I use this with old Source games (CS:S, HL2, ...)

Yes, with limited features (phong tinting won't work, I don't know if rimlight works as good).


> Do I have to credit you?

That'd be nice but no.