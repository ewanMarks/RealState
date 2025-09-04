namespace RealState.Domain.RealState.Properties.ValueObjects;

/// <summary>
/// Objeto de valor que encapsula los filtros de búsqueda para la entidad <see cref="Property"/>.
/// </summary>
public sealed record PropertyFilters(
    /// <summary>
    /// Identificador del propietario asociado a las propiedades (opcional).
    /// </summary>
    Guid? IdOwner,

    /// <summary>
    /// Nombre de la propiedad (búsqueda parcial o exacta).
    /// </summary>
    string? Name,

    /// <summary>
    /// Dirección de la propiedad (búsqueda parcial o exacta).
    /// </summary>
    string? Address,

    /// <summary>
    /// Código interno de la propiedad.
    /// </summary>
    string? CodeInternal,

    /// <summary>
    /// Precio mínimo permitido en el filtro.
    /// </summary>
    decimal? PriceMin,

    /// <summary>
    /// Precio máximo permitido en el filtro.
    /// </summary>
    decimal? PriceMax,

    /// <summary>
    /// Año mínimo de construcción permitido en el filtro.
    /// </summary>
    int? YearMin,

    /// <summary>
    /// Año máximo de construcción permitido en el filtro.
    /// </summary>
    int? YearMax,

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
    /// Campo por el cual ordenar los resultados (ej. "Name", "Price", "Year").
    /// </summary>
    string? SortBy,

    /// <summary>
    /// Dirección del ordenamiento: "ASC" o "DESC".
    /// </summary>
    string? SortDir
);