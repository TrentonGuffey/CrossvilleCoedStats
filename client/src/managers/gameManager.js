const apiUrl = "/api/game";

export const getGames = () => {
    return fetch(apiUrl).then((res) => res.json());
};

export const getGameById = (id) => {
    return fetch(`${apiUrl}/${id}`).then((res) => res.json());
};