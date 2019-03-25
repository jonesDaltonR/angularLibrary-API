export class Book {
    id: number;
    title: string;
    description: string;
    isbn: string;
    genre: string;

    constructor(id: number, t: string, d: string, i: string, g: string) {
        this.id = id;
        this.title = t;
        this.description = d;
        this.isbn = i;
        this.genre = g;
    }
}
