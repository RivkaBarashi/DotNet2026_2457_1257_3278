

namespace DalApi;


using DO;

public interface ICustomer
{
    /// <summary>
    /// פונקציה ליצירת אוביקט
    /// </summary>
    /// <param name="item">מקבלת פרטי לקוח</param>
    /// <returns>מחזירה את קוד הלקוח שנוצר</returns>
    int Create(Customer item);
    /// <summary>
    ///     פונקציה שמחזירה לקוח לפי המזהה שקבלה
    /// </summary>
    /// <param name="id">מזהה הלקוח הרצוי</param>
    /// <returns>מחזירה את הלקוח המבוקש</returns>
    Customer? Read(int id);
    /// <summary>
    /// פונקציה שמחזירה רשימה של כל הלקוחות
    /// </summary>
    /// <returns>רשימת הלקוחות</returns>
    List<Customer?> ReadAll();
    /// <summary>
    ///פונקציה שמעדכנת נתוני לקוח 
    /// </summary>
    /// <param name="item">מקבלת פרטי לקוח</param>
    /// 
    void Update(Customer item);
    /// <summary>
    /// מוחקת לקוח לפי המזהה שקבלה
    /// </summary>
    /// <param name="id">מקבלת את מזהה הלקוח הרצוי למחיקה</param>
    void Delete(int id);
}