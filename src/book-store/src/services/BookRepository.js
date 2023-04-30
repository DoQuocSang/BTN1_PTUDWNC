import axios from 'axios';
import { get_api } from './Method';

export function getRandomBooks(
    numBooks = 3
    ) {     
    return get_api(`https://localhost:7245/api/books/random/{limit}?numBooks=${numBooks}`)
}

export function getBooks(
    PageSize = 30,
    PageNumber = 1
    ) {     
    return get_api(`https://localhost:7245/api/books?PageSize=${PageSize}&PageNumber=${PageNumber}`)
}