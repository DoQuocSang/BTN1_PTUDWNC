import axios from 'axios';
import { get_api } from './Method';

export function getBooks(
    numBooks = 3
    ) {     
    return get_api(`https://localhost:7245/api/books/random/{limit}?numBooks=${numBooks}`)
}