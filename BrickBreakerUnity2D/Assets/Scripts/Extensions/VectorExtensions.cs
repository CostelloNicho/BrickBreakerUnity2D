// Copyright 2014 Nicholas Costello <NicholasJCostello@gmail.com>

using UnityEngine;

public static class VectorExtensions
{

	public static Vector3 ToVector3(this Vector2 coordinate)
	{
		return new Vector3(coordinate.x, coordinate.y, 0f);
	}

    /// <summary>
    /// Converts any Vector3 to a 2d Vector3 with a zero z value
    /// </summary>
    /// <param name="Vector3 coordinate"></param>
    /// <returns></returns>
    public static Vector3 ToVector3_2D(this Vector3 coordinate)
    {
        return new Vector3(coordinate.x, coordinate.y, 0);
    }

    /// <summary>
    /// Converts a vector 3 to a vector 2
    /// </summary>
    /// <param name="coordinate"></param>
    /// <returns></returns>
    public static Vector2 ToVector2(this Vector3 coordinate)
    {
        return new Vector2(coordinate.x, coordinate.y);
    }

    /// <summary>
    /// Converts a screen space coordinate and returns a Vector2 in 2D
    /// example: returns: vector2(x,y);
    /// </summary>
    /// <param name="screenCoordinate"></param>
    /// <returns></returns>
    public static Vector2 GetScreenPosition2D(this Vector3 screenCoordinate)
    {
        Vector3 wouldCoordinate = Camera.main.ScreenToWorldPoint(screenCoordinate);
        return new Vector2(wouldCoordinate.x, wouldCoordinate.y);
    }

    /// <summary>
    /// Converts a screen space coordinate and returns a Vector3 with a zero z value for 2D
    /// example: returns: vector3(x,y,0)
    /// </summary>
    /// <param name="screenCoordinate"></param>
    /// <returns></returns>
    public static Vector3 GetScreenPositionFor2D(this Vector3 screenCoordinate)
    {
        Vector3 wouldCoordinate = Camera.main.ScreenToWorldPoint(screenCoordinate);
        return wouldCoordinate.ToVector3_2D();
    }
}