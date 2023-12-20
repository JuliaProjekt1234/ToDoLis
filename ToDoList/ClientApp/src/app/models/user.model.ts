export class UserToAdd {
    constructor(
        public name: string,
        public password: string,
        public confirmedPassword: string
    ) { }
}

export class User{
    constructor(
        public name: string,
        public password: string,
    ) { }
}