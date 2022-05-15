import MathFunction from "../scripts/MathFunc.js";
jest.mock("../scripts/MathFunc.js");


it("Do something", () => {

    matrixTest = [
        [4, 2, 5, 0],
        [8, 1, 2, 0],
        [4, 2, 4, 0]
    ];

    matrixResult = [
        [4, 2, 5, 0],
        [0, 2, 4, 0],
        [0, 0, 0, 0]
    ];

    expect(MathFunction.matrixScale(matrixTest)).toMatchObject(matrixResult);;

});