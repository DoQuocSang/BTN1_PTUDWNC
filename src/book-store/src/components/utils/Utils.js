import React, { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import Moment from 'moment';


export function isEmptyOrSpaces(str) {
    return str == null || (typeof str === 'string' && str.match(/^ *$/) !== null);
}

export function useQuery() {
    const { search } = useLocation();
    return React.useMemo(() => new URLSearchParams(search), [search]);
}

export function toVND(value) {
    return value.toLocaleString('it-IT', {style : 'currency', currency : 'VND'});
}

export function formatDateTme(value) {
    const time =  " - " + Moment(value).format("kk:mm:ss");
    const date =  "Ngày đăng: " + Moment(value).format("DD/MM/YYYY");
    return date + time;
}
