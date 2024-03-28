using PangLib.IFF.Model.US.Season8.Data;

namespace PangLib.IFF.Model.US.Season8.Extension;

public static class CourseExtensions
{
    public static (byte difficultyNum, byte unknown) GetDifficulty(this Course course) =>
        ((byte)(course.Difficulty & 0xF), (byte)(course.Difficulty >> 4));

    public static byte FormDifficulty(this (byte difficultyNum, byte unknown) difficulty) =>
        (byte)((difficulty.unknown << 4) | (difficulty.difficultyNum & 0xF));
}