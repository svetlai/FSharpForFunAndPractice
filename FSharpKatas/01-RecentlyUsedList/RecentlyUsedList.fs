module RecentlyUsedList

open System
open System.Collections.Generic

type RecentlyUsedList(capacity : Option<int>) =
    let mutable items : string list = List.empty
    let validateIndex i validAction =
        let isValidIndex = 0 <= i && i < items.Length
        match isValidIndex with
        | true -> validAction
        | false -> raise (new IndexOutOfRangeException "Index was out of range.")

    let removeAtIndex i =
        let itemToDelete = validateIndex i items.[i]
        let result  = 
            items |> List.filter (fun x -> x <> itemToDelete)
        items <- result
        itemToDelete

    new() =
        new RecentlyUsedList(Some 5)

    member x.Add newItem = 
        let isItemValid =
            match newItem with
            | "" | null -> nullArg "Adding null or empty value is not allowed."
            | _ -> true
                
        let result =
            match isItemValid with
            | true -> 
                let hasReachedCapacity = 
                    match capacity with
                    | Some c -> items.Length = c
                    | None -> false

                let items = 
                    match hasReachedCapacity with
                    | true -> 
                        removeAtIndex (items.Length - 1) |> ignore
                        items
                    | false -> items
                
                let items = 
                    let existingItem = items |> Seq.tryFind ((=) newItem)
                    match existingItem with
                    | Some item -> items |> List.filter (fun x -> x <> item)
                    | None -> items

                newItem :: items
            | false -> items
        items <- result

    member x.Item with get(i:int) =
        validateIndex i items.[i]

    member x.Remove =
         match items.Length > 0 with
            | true -> removeAtIndex 0
            | false -> invalidOp "The list is empty."
     
    member x.Count =
        items.Length

    member x.Capacity =
        capacity

    override x.ToString() =
        items.ToString()
