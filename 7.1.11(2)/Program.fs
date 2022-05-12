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


//Дан целочисленный массив, в котором лишь один элемент отличается от остальных. Необходимо найти значение этого элемента.
let OtherElement list = 
    if List.findIndex (fun x-> x = (List.max list)) list = List.findIndexBack (fun x-> x = (List.max list)) list  then List.max list //элемент который отличается от остальных
    else List.min list

[<EntryPoint>]
let main argv =
   let list1= readData 
   let res= OtherElement list1
   Console.WriteLine("Элемент,который отличается от остальных:{0}",res)
   0 