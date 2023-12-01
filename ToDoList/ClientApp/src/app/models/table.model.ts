export class BaseTable {
    constructor(
        public name: string,
        public color: string,
        public description: string
    ) { }
}


export class Table extends BaseTable {
    constructor(
        public id: number,
        name: string,
        color: string,
        description: string
    ) {
        super(name, color, description);
    }
}