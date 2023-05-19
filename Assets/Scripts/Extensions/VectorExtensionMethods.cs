using UnityEngine;

public static class VectorExtensionMethods
{

	public static Vector2 Multiply(this Vector2 vector2, Vector2 otherVector2)
    {
		return new Vector2(vector2.x * otherVector2.x, vector2.y * otherVector2.y);
    }
	public static Vector3 Multiply(this Vector3 vector3, Vector3 otherVector3)
    {
		return new Vector3(vector3.x * otherVector3.x, vector3.y * otherVector3.y, vector3.z * otherVector3.z);
    }
	/// <summary>
	/// Converts Vector2 to Vector3 with y as 0.
	/// </summary>
	/// <returns> Vector3 with y 0.</returns>
	public static Vector3 ConvertV2ToV3_XZ_plane(this Vector2 v)
    {
		return new Vector3(v.x, 0, v.y);
    }
	public static Vector3 ConvertV3_XYToV3_XZ(this Vector3 v)
    {
		return new Vector3(v.x, 0, v.y);
    }
	/// <summary>
	/// 
	/// </summary>
	/// <param name="v"></param>
	/// <returns>Clone of vector provided</returns>
	public static Vector2 Clone(this Vector3 v)
	{
		return new Vector2(v.x, v.y);
	}
    /// <summary>
    /// adds x float value to vector
    /// </summary>
    /// <returns> Changed vector with x value increamented</returns>

    public static Vector3 WithX(this Vector3 v, float x)
	{
		return new Vector3(x, v.y, v.z);
	}
	/// <summary>
	/// adds y float value to vector
	/// </summary>
	/// <returns> Changed vector with y value increamented</returns>
	public static Vector3 WithY(this Vector3 v, float y)
	{
		return new Vector3(v.x, y, v.z);
	}
    /// <summary>
    /// adds z float value to vector
    /// </summary>
    /// <returns> Changed vector with z value increamented</returns>

    public static Vector3 WithZ(this Vector3 v, float z)
	{
		return new Vector3(v.x, v.y, z);
	}
    /// <summary>
    /// adds x float value to vector
    /// </summary>
    /// <returns> Changed vector with x value increamented</returns>

    public static Vector2 WithX(this Vector2 v, float x)
	{
		return new Vector2(x, v.y);
	}
    /// <summary>
    /// adds y float value to vector
    /// </summary>
    /// <returns> Changed vector with y value increamented</returns>

    public static Vector2 WithY(this Vector2 v, float y)
	{
		return new Vector2(v.x, y);
	}
    /// <summary>
    /// adds z float value to vector
    /// </summary>
    /// <returns> Changed vector with z value increamented</returns>

    public static Vector3 WithZ(this Vector2 v, float z)
	{
		return new Vector3(v.x, v.y, z);
	}

	// axisDirection - unit vector in direction of an axis (eg, defines a line that passes through zero)
	// point - the point to find nearest on line for
	public static Vector3 NearestPointOnAxis(this Vector3 axisDirection, Vector3 point, bool isNormalized = false)
	{
		if (!isNormalized) axisDirection.Normalize();
		var d = Vector3.Dot(point, axisDirection);
		return axisDirection * d;
	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="lineDirection">unit vector in direction of line</param>
	/// <param name="point">the point to find nearest on line for</param>
	/// <param name="pointOnLine">a point on the line (allowing us to define an actual line in space</param>
	/// <param name="isNormalized"></param>
	/// <returns></returns>
	public static Vector3 NearestPointOnLine(
		this Vector3 lineDirection, Vector3 point, Vector3 pointOnLine, bool isNormalized = false)
	{
		if (!isNormalized) lineDirection.Normalize();
		var d = Vector3.Dot(point - pointOnLine, lineDirection);
		return pointOnLine + (lineDirection * d);
	}
}