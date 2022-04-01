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

//Дан массив и индекс,определить является ли элемент по указанному индексу локальным минимумом

let LocalMin Index list = 
    let rec localmin list ind ElByInd IndEl = //ElByInd - значение в списке с заданным индексом
        match list with
        |[]->true
        |head::tail->
            let result=
                if (IndEl+1=ind || IndEl=ind) then
                    if (IndEl=ind) then localmin tail ind head (IndEl+1) 
                    else
                        if (head>=tail.Head && IndEl+1=ind) then localmin tail ind tail.Head (IndEl+1)
                        else false
                else               
                    if (IndEl-1=ind && head>=ElByInd) then true
                        else false
            if (IndEl>=ind-1 && IndEl<=ind+1) then result
            else
                localmin tail ind ElByInd (IndEl+1)
    localmin list Index 0 0 

       
[<EntryPoint>]
let main argv =
    Console.WriteLine("Введите индекс: ")
    let ind = Convert.ToInt32(Console.ReadLine())
    Console.WriteLine("Результат: ")
    readData |> LocalMin ind |> Console.WriteLine
    0 