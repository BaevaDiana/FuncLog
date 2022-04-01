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

//Дан массив. Найти количество минимальных элементов

//поиск минимального элемента
let Min list = 
    let rec min list mn =
        match list with
        |[]->mn
        |h::tail -> 
            let newMin = 
                if h<mn then mn 
                else h
            min tail newMin 
    min list list.Head

//считаем количество минимумов
let CountMin list = 
  let rec countmin list minel num=
      match list with
      |[] -> num
      |h::tail->
        let newNum = 
            if h=minel then num+1
            else num
        countmin tail minel newNum
  countmin list list.Head 0

    
[<EntryPoint>]
let main argv =
    Console.WriteLine("Колиечство минимальных элементов: ")
    readData |> CountMin|>Console.WriteLine
    0 