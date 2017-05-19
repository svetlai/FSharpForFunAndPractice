// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open RecentlyUsedList

[<EntryPoint>]
let main argv = 
    let list = new RecentlyUsedList()
    
    printfn "--Init list. \nCount: %A" list.Count
    printfn "Capacity: %A" list.Capacity

    list.Add "first string" |> ignore
    printfn "--Add item. \nGet: %A" list.Get
    list.Add "second string"  |> ignore
    printfn "--Add another item. \nGet: %A" list.Get
//  list.Add "second string" |> ignore // throws Invalid argument
    
    printfn "Count: %A" list.Count
    printfn "Element at index 0: %A" list.[0]
//  list.[3] |> ignore // throws Index out of range.

    list.Remove "second string" |> ignore
    printfn "--Remove item. \nGet: %A" list.Get
    printfn "Count: %A" list.Count
    list.RemoveAtIndex 0 |> ignore
    printfn "--Remove at index 0. \nGet: %A" list.Get
    printfn "Count: %A" list.Count

    let listWithCapacity = new RecentlyUsedList(2)
    printfn "-- New list with capacity. \nCapacity: %A" listWithCapacity.Capacity
    listWithCapacity.Add "first string" |> ignore
    listWithCapacity.Add "second string" |> ignore
    printfn "Count: %A" list.Count
    printfn "Add items. \nGet: %A" listWithCapacity.Get
    listWithCapacity.Add "third string" |> ignore
    printfn "Add item over capacity. \nGet: %A" listWithCapacity.Get

    0 // return an integer exit code
