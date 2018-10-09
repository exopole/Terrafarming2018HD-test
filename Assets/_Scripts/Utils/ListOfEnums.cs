using System;

public enum PlantTypeEnum
{
    none,
    flower,
    bush,
    tree
}

public enum ressourceEnum
{
    bush,
    tree,
    flower,
    ore,
    essence
}

public enum PlantStateEnum
{
    debris,
    lopin,
    seed,
    baby,
    teenage,
    grownup
}

public enum BiomeEnum
{
    none,
    plain,
    crater,
    cave
}

public enum AnimeParameters
{
    iswalking,
    isplanting,
    ismining,
    mininghit,
    isjumping,
    isflying,
    isfalling,
    islanding,
    isvictory,
    iscleaning,
    iswatering
}

public enum DayStates
{
    Day,
    Night
}

[Flags]
public enum TerrainEnum : int
{
    water = 1,
    fire = 2,
    acid = 4,
}