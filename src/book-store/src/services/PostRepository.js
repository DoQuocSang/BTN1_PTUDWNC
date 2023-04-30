import axios from 'axios';
import { get_api } from './Method';

export function getFeaturedPosts(
    numBooks=2
    ) {     
    return get_api(`https://localhost:7245/api/posts/featured/{limit}?numPosts=${numBooks}`)
}

export function getRandomPosts(
    numBooks=6
    ) {     
    return get_api(`https://localhost:7245/api/posts/random/{limit}?numPosts=${numBooks}`)
}