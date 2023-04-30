import React, { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";

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