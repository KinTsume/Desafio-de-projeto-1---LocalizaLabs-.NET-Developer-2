export default class MathFunc{
    constructor(){
        this.matrixTest = [
            [4, 2, 5, 0],
            [-3, 1, 2, 0],
            [3, 2, 4, 0]
        ];
    }

    matrixScale = (matrix) => {
        let pivot = {
            line: 0,
            column: 0
        };
        let length = matrix.length;
        
        for(let i = 0; i < length - 1; i++){
            let pivotValue = matrix[pivot.line][pivot.column];
            let pivotLine = matrix[pivot.line];

            for(let j = 1; j < matrix.length - pivot.line; j++){
                matrix[pivot.line + j] = this.handleLineMultiplying(pivotLine, matrix[pivot.line + j], pivot.column);
            }

            pivot.line++;
            pivot.column++;
        }

        return matrix;
    }

    handleLineMultiplying(pivotLine, line, pivotColumn){

        console.log("Pivot: "+pivotLine);
        console.log("Line: "+line);
        let multiplier = pivotLine[pivotColumn] != 0 ? (line[pivotColumn] / pivotLine[pivotColumn]) : 0;
        let resultLine = [];
        for(let i = 0; i < line.length; i++){
            
            resultLine[i] = line[i] - multiplier * pivotLine[i];
        }

        return resultLine;
    }

    solveScaledMatrix = () => {
        
    }
}