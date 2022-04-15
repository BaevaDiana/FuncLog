open System

//Создать новый массив, в котором порядок элементов существующего массива будет изменен на обратный (Привет ->тевирП).

//ввод массива
let readArray n =
    let rec readarray n arr = 
        match n with 
        |0 ->arr
        |_->
            let newEl=Console.ReadLine()|>Convert.ToInt32
            let newArr = Array.append arr [|newEl|]
            readarray (n-1) newArr
    readarray n [||]

//вывод массива
let writeArray arr = 
    printfn "%A" arr

[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите размерность массива,затем элементы массива:")
    let newArray= Console.ReadLine() |> Convert.ToInt32|>readArray
    let ResultArray = Array.rev newArray
    Console.WriteLine("Результирующий массив:")
    writeArray ResultArray
    0