const gamesApiUrl = "/api/games";
const teamApiUrl = "/api/teams";

export const getGames = () => {
    return fetch(gamesApiUrl).then((res) => res.json());
};

export const getGameById = (id) => {
    return fetch(`${gamesApiUrl}/${id}`).then((res) => res.json());
};

export const getTeams = () => {
    return fetch(teamApiUrl).then((res) => res.json());
};