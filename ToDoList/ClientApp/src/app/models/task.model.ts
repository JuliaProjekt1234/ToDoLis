export class BaseTask {
    constructor(
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
        done: boolean
    ) {
        super(name, description, done)
    }
}