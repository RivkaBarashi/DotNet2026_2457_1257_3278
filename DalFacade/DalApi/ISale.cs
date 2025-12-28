
namespace DalApi;


using DO;

public interface ISale
{
    /// <summary>
    /// פונקציה ליצירת מבצע
    /// </summary>
    /// <param name="item">מקבלת פרטי מבצע</param>
    /// <returns>מחזירה את קוד המבצע שנוצר</returns>
    int Create(Sale item);
    /// <summary>
    ///     פונקציה שמחזירה פרטי מבצע לפי המזהה שקבלה
    /// </summary>
    /// <param name="id">מזהה המבצע הרצוי</param>
    /// <returns>מחזירה את פרטי המבצע המבוקש</returns>
    Sale? Read(int id);
    /// <summary>
    /// פונקציה שמחזירה רשימה של כל המבצעים
    /// </summary>
    /// <returns>רשימת המבצעים</returns>
    List<Sale?> ReadAll();
    /// <summary>
    ///פונקציה שמעדכנת נתוני מבצע 
    /// </summary>
    /// <param name="item">מקבלת פרטי מבצע</param>
    /// 
    void Update(Sale item);
    /// <summary>
    /// מוחקת מבצע לפי המזהה שקבלה
    /// </summary>
    /// <param name="id">מקבלת את מזהה מבצע הרצוי למחיקה</param>
    void Delete(int id);
}
