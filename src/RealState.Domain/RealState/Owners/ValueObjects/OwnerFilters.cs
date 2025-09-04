namespace RealState.Domain.RealState.Owners.ValueObjects;

/// <summary>
/// Objeto de valor que encapsula los filtros de búsqueda para la entidad <see cref="Owner"/>.
/// </summary>
public sealed record OwnerFilters(
    /// <summary>
    /// Nombre del propietario (búsqueda parcial o exacta).
    /// </summary>
    string? Name,

    /// <summary>
    /// Dirección del propietario (búsqueda parcial o exacta).
    /// </summary>
    string? Address,

    /// <summary>
    /// Fecha mínima de cumpleaños permitida en el filtro.
    /// </summary>
    DateOnly? BirthdayMin,

    /// <summary>
    /// Fecha máxima de cumpleaños permitida en el filtro.
    /// </summary>
    DateOnly? BirthdayMax,

    /// <summary>
    /// Fecha mínima de creación del registro.
    /// </summary>
    DateTime? CreatedFrom,

    /// <summary>
    /// Fecha máxima de creación del registro.
    /// </summary>
    DateTime? CreatedTo,

    /// <summary>
    /// Número de página (para paginación).
    /// </summary>
    int Page,

    /// <summary>
    /// Tamaño de página (para paginación).
    /// </summary>
    int PageSize,

    /// <summary>
    /// Campo por el cual ordenar los resultados (ej. "Name", "CreatedOn").
    /// </summary>
    string? SortBy,

    /// <summary>
    /// Dirección del ordenamiento: "ASC" o "DESC".
    /// </summary>
    string? SortDir
);