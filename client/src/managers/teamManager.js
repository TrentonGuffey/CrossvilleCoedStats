const apiUrl = "/api/teams";

export const getTeams = () => {
    return fetch(apiUrl).then((res) => res.json());
};