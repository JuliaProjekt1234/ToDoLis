import { Task } from "./task.model";

export class BaseTable {
    constructor(
        public name: string,
        public color: string,
        public description: string,
    ) { }
}


export class Table extends BaseTable {
    constructor(
        public id: number,
        public tasks: Task[],
        name: string,
        color: string,
        description: string,
    ) {
        super(name, color, description);
    }

    public static CreateDefault() {
        return new Table(0, [], "", "", "");
    }
}