open System

let rec readList n = 
    if n=0 then []
    else
    let Head = System.Convert.ToInt32(System.Console.ReadLine())
    let Tail = readList (n-1)
    Head::Tail

let readData = 
    Console.WriteLine("Введите размерность списка:  ")
    let n=System.Convert.ToInt32(System.Console.ReadLine())
    Console.WriteLine("Введите список: ")
    readList n

let rec writeList = function
    [] ->   let z = System.Console.ReadKey()
            0
    | (head : int)::tail -> 
                       System.Console.WriteLine(head)
                       writeList tail

//Дан целочисленный массив. Необходимо найти количество элементов, расположенных после последнего максимального.

let CountAfterMax list = List.length list - (List.findIndexBack (fun x-> x=(List.max list) ) list)-1 

[<EntryPoint>]
let main argv =
   Console.WriteLine("Количество элементов после последнего максимального:")
   readData|> CountAfterMax  |>Console.WriteLine;
    0 