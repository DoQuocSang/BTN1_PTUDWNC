import axios from 'axios';
import { get_api } from './Method';

export function getAuthors(
    PageSize = 30,
    PageNumber = 1
    ) {     
    return get_api(`https://localhost:7245/api/authors?PageSize=${PageSize}&PageNumber=${PageNumber}`)
}

export function getAuthorBySlug(
    slug = ""
    ) {     
    return get_api(`https://localhost:7245/api/authors/${slug}`)
}

