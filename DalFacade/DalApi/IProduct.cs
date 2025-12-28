

namespace DalApi;


using DO;

public interface IProduct
{
    /// <summary>
    /// פונקציה ליצירת אוביקט
    /// </summary>
    /// <param name="item">מקבלת פרטי המוצר</param>
    /// <returns>מחזירה את קוד המוצר שנוצר</returns>
    int Create(Product item);
    /// <summary>
    ///     פונקציה שמחזירה מוצר לפי המזהה שקבלה
    /// </summary>
    /// <param name="id">מזהה המוצר הרצוי</param>
    /// <returns>מחזירה את המוצר המבוקש</returns>
    Product? Read(int id);
    /// <summary>
    /// פונקציה שמחזירה רשימה של כל המוצרים
    /// </summary>
    /// <returns>רשימת המוצרים</returns>
    List<Product?> ReadAll();
    /// <summary>
    ///פונקציה שמעדכנת נתוני מוצר 
    /// </summary>
    /// <param name="item">מקבלת פרטי מוצר</param>
    /// 
    void Update(Product item);
    /// <summary>
    /// מוחקת מוצר לפי המזהה שקבלה
    /// </summary>
    /// <param name="id">מקבלת את מזהה המוצר הרצוי למחיקה</param>
    void Delete(int id);
}
