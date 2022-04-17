//This is a study of Object Oriented Programming in javascript

class contaBancaria{
    constructor(agencia, numero, tipo){
        this.agencia = agencia;
        this.numero = numero;
        this.tipo = tipo;
        this._saldo = 0;
    }

    get saldo(){
        return this._saldo;
    }

    set saldo(valor){
        this._saldo = valor;
    }

    sacar(valor){
        if(this._saldo < valor){
            return 'Operação inválida: saldo insuficiente';
        }
            
        this._saldo -= valor;
        return 'Operação realizada com sucesso. Novo saldo: '+this.saldo;
    }

    depositar(valor){
        this._saldo += valor;
        return this._saldo;
    }
}

class contaCorrente extends contaBancaria{
    constructor(agencia, numero, cartaoCredito){
        super(agencia, numero);

        this.tipo = 'corrente';
        this.cartaoCredito = cartaoCredito;
    }

    get cartaoCredito(){
        return this.cartaoCredito;
    }

    set cartaoCredito(valor){
        this.cartaoCredito = valor;
    }

}

class contaPoupanca extends contaBancaria{
    constructor(agencia, numero){
        super(agencia, numero);

        this.tipo = 'poupança';
    }

}

class contaUniversitaria extends contaBancaria{
    constructor(agencia, numero){
        super(agencia, numero);

        this.tipo = 'universitária';
    }

    sacar(valor){
        if(valor > 500){
            return 'Operação inválida: só é possível sacar valores menores que 500'
        }

        this._saldo -= valor;
    }

}