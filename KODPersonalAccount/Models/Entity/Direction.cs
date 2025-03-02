namespace KODPersonalAccount.Applications.Models.Entity;

/// <summary>
/// Направление.
/// </summary>
public class Direction
{
    /// <summary>
    /// Название.
    /// </summary>
    public string Title { get; private set; }
    
    /// <summary>
    /// Описание.
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// Создание на основе первичных данных.
    /// </summary>
    /// <param name="title">Название.</param>
    /// <param name="description">Описание.</param>
    public Direction(
        string title,
        string description)
    {
        SetTitle(
            title);
        
        SetDescription(
            description);
    }

    /// <summary>
    /// Установить название.
    /// </summary>
    /// <param name="title">Название.</param>
    private void SetTitle(
        string title)
    {
        title = title.Trim();

        if (title != string.Empty && title.Length <= 128)
        {
            Title = title;
        }
    }
    
    /// <summary>
    /// Установить описание.
    /// </summary>
    /// <param name="description">Описание.</param>
    public void SetDescription(
        string description)
    {
        description = description.Trim();

        if (description != string.Empty)
        {
            Description = description;
        }
    }
}
