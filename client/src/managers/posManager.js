const apiUrl = "/api/positions";

export const getPositions = () => {
    return fetch(apiUrl).then((res) => res.json());
};