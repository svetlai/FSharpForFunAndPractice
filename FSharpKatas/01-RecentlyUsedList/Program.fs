// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open RecentlyUsedList

[<EntryPoint>]
let main argv = 
    let list = new RecentlyUsedList()
    
    printfn "--Init list with default capacity \nCount: %A" list.Count
    printfn "Capacity: %A" list.Capacity

//    list.Remove |> ignore // throws Invalid operation
    list.Add "first string" |> ignore
    printfn "--Add item \nList: %O" list
    list.Add "second string"  |> ignore
    printfn "--Add another item \nList: %A" list
    list.Add "first string" |> ignore
    printfn "--Add non-unique item \nList: %A" list
    
    printfn "Count: %A" list.Count
    printfn "Element at index 0: %A" list.[0]
//  list.[3] |> ignore // throws Index out of range.

    list.Remove |> ignore
    printfn "--Remove item. \nList: %A" list
    printfn "Count: %A" list.Count

    let listWithCustomCapacity = new RecentlyUsedList(Some 2)
    printfn "-- New list with capacity \nCapacity: %A" listWithCustomCapacity.Capacity
    listWithCustomCapacity.Add "first string" |> ignore
    listWithCustomCapacity.Add "second string" |> ignore
    printfn "Count: %A" list.Count
    printfn "Add items \nList: %A" listWithCustomCapacity
    listWithCustomCapacity.Add "third string" |> ignore
    printfn "Add item over capacity \nList: %A" listWithCustomCapacity

    let listWithNoCapacity = new RecentlyUsedList(None)
    printfn "-- New list with no capacity \nCapacity: %A" listWithNoCapacity.Capacity
    listWithNoCapacity.Add "first string" |> ignore
    listWithNoCapacity.Add "second string" |> ignore
    listWithNoCapacity.Add "third string" |> ignore
    listWithNoCapacity.Add "forth string" |> ignore
    listWithNoCapacity.Add "fifth string" |> ignore
    listWithNoCapacity.Add "sixth string" |> ignore
    printfn "Add items \nCount: %A" listWithNoCapacity.Count
    printfn "List: %A" listWithNoCapacity
    0 // return an integer exit code
