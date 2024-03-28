using PangLib.IFF.Model.Data;

namespace PangLib.IFF.Extension;

public static class CourseExtensions
{
    public static (byte difficultyNum, byte unknown) GetDifficulty(this CourseUs8 courseS8Us) =>
        ((byte)(courseS8Us.Difficulty & 0xF), (byte)(courseS8Us.Difficulty >> 4));

    public static byte FormDifficulty(this (byte difficultyNum, byte unknown) difficulty) =>
        (byte)((difficulty.unknown << 4) | (difficulty.difficultyNum & 0xF));
}