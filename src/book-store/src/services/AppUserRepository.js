import axios from 'axios';
import { get_api } from './Method';
import { post_api } from './Method';

export function getUsers(
    PageSize = 30,
    PageNumber = 1
    ) {     
    return get_api(`https://localhost:7245/api/users?PageSize=${PageSize}&PageNumber=${PageNumber}`)
}

