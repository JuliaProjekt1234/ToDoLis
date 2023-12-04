export class BaseTask {
    constructor(
        public tableId: number,
        public name: string,
        public description: string,
        public done: boolean
    ) { }
}

export class Task extends BaseTask {
    constructor(
        public id: number,
        name: string,
        description: string,
        done: boolean,
        tableId: number
    ) {
        super(tableId, name, description, done)
    }

    public static CreateDefault(): Task {
        return new Task(0, "", "", false, 0);
    }
}