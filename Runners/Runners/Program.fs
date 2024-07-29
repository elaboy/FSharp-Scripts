open System
open System.Diagnostics
open System.IO

let runCMDMetaMorpheus =
    let cmd = @"E:\MetaMorpheusVersions\MetaMorpheus\CMD\bin\Release\net6.0\CMD.exe"
    let baseForRawFiles = @"E:\Datasets\Mann_11cell_lines\A549"

    let files_1 = Directory.GetFiles(
        Path.Join(baseForRawFiles, "A549_1"), "*.raw")

    let files_2 = Directory.GetFiles(
        Path.Join(baseForRawFiles, "A549_2"), "*.raw")

    let files_3 = Directory.GetFiles(
        Path.Join(baseForRawFiles, "A549_3"), "*.raw")

    let rawFiles = String.Concat("-s", " ", files_1 
        |> String.concat(" "), " ", files_2 
        |> String.concat(" "), " ", files_3 
        |> String.concat(" "))
       
    let tasks = Directory.GetFiles(
        Path.Join(baseForRawFiles, "TaskSettings"))

    let tasksConcat = String.Concat("-t", " ", tasks 
        |> String.concat(" "))

    let proteome = @"-d E:\Proteomes\uniprotkb_proteome_UP000005640_AND_revi_2024_07_08.xml "

    let outputPath = @"-o E:\Datasets\Mann_11cell_lines\A549\ClassicSearchChronologer"

    //run the process 
    let runMM = Process.Start(
        cmd, 
        String.Concat(
            rawFiles, " ", tasksConcat, " ", proteome, " ", outputPath))
    
    runMM.WaitForExit()

    printfn "%s " "Done"

runCMDMetaMorpheus