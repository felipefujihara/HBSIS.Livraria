export class Book {
    constructor(
        public id: string, 
        public name: string, 
        public category: string) 
    { }
}

export class ResponseResult {
    constructor(
        public statusCode: number, 
        public message: string) 
    { }
}