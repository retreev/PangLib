using System.Collections.Generic;

namespace PangLib.SBIN.Models;

public class ShadowMap
{
    public List<Vertex> Vertices;
    public List<Vector3<float>> Mesh3D;
    public List<Vector2<float>> Mesh2D;
    public List<Texture> GlobalTextures;
    public List<Texture> Type0Textures;
    public List<Texture> Type1Textures;
    public List<int> GlobalNumberValues;
    public List<int> Type0NumberValues;
    public List<int> Type1NumberValues;
    public List<long> GlobalValues;
    public List<long> Type0Values;
    public List<long> Type1Values;
}