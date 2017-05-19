module RecentlyUsedList

open System
open System.Collections.Generic

type RecentlyUsedList(capacity : int) =
    let mutable items = List.empty

    new() = new RecentlyUsedList(5)

    member x.Get =
        items
            
    member x.Add newItem = 
        let isItemValid =
            match newItem with
            | "" | null -> nullArg "Adding null or empty value is not allowed."
            | _ ->
                let itemExists = items |> Seq.exists ((=) newItem)
                match itemExists with
                | true -> invalidArg newItem "The item already exists."
                | false -> true

        let result =
            match isItemValid with
            | true -> 
                let hasReachedCapacity = items.Length = capacity
                let items = 
                    match hasReachedCapacity with
                    | true -> 
                        x.RemoveAtIndex (items.Length - 1) |> ignore
                        items
                    | false -> items
                newItem :: items
            | false -> items
        items <- result
        newItem

    member x.Item with get(i:int) =
        let isValidIndex = 0 <= i && i < items.Length
        match isValidIndex with
        | true -> items.[i]
        | false -> raise (new IndexOutOfRangeException "Index was out of range.")

    member x.Remove itemToDelete =
        let result  = 
            items |> List.filter (fun x -> x <> itemToDelete)
        items <- result
        itemToDelete

    member x.RemoveAtIndex i =
        let itemToDelete = x.[i]
        x.Remove itemToDelete

    member x.Count =
        items.Length

    member x.Capacity =
        capacity

