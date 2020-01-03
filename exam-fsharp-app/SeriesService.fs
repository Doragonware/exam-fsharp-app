namespace SeriesService

type Serie =
    { id: int
      title: string
      episodes: int }


type ISeriesService =
    abstract member GetAllSeries: unit -> Serie list
    abstract member GetSerie: int -> Serie

type SeriesService() =

    let notFound: Serie =
        { id = 0
          title = "NOT FOUND"
          episodes = 0 }

    let seriesDB =
        [ { id = 1
            title = "The Witcher"
            episodes = 10 }
          { id = 2
            title = "Attack on Titan"
            episodes = 24 } ]

    interface ISeriesService with
        member __.GetAllSeries() = seriesDB
        member __.GetSerie(id: int) =
            let result = seriesDB |> List.tryItem id
            match result with
            | Some value -> value
            | None -> notFound
