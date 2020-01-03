namespace exam_fsharp_app.Controllers

open Microsoft.AspNetCore.Mvc
open SeriesService

[<ApiController>]
[<Route("[controller]")>]
type SeriesController(service: ISeriesService) =
    inherit ControllerBase()


    [<HttpGet>]
    member this.Get() =
        let series = service.GetAllSeries()
        ActionResult<Serie list>(series)


    [<HttpGet("{id}")>]
    member this.Get(id: int) =
        let serie = service.GetSerie(id)
        ActionResult<Serie>(serie)
 