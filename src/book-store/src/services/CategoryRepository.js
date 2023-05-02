import axios from 'axios';
import { get_api } from './Method';

export function getCategories(
    PageSize = 30,
    PageNumber = 1
    ) {     
    return get_api(`https://localhost:7245/api/categories?PageSize=${PageSize}&PageNumber=${PageNumber}`)
}

export function getCategoryBySlug(
    slug = ""
    ) {     
    return get_api(`https://localhost:7245/api/categories/${slug}`)
}

export function getPostsByCategorySlug(
    slug = "",
    PageSize = 30,
    PageNumber = 1
    ) {     
    return get_api(`https://localhost:7245/api/categories/${slug}/posts?PageSize=${PageSize}&PageNumber=${PageNumber}`)
}

