const apiUrl = "/api/player";

export const getPlayers = () => {
    return fetch(apiUrl).then((res) => res.json());
};

export const getPlayerById = (id) => {
    return fetch(`${apiUrl}/${id}`).then((res) => res.json());
};