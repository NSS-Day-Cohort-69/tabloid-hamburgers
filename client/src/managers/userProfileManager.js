const _apiUrl = "/api/userprofile";

export const getProfiles = () => {
  return fetch(_apiUrl + "/withroles").then((res) => res.json());
};

export const getProfile = (id) => {
  return fetch(_apiUrl + `/${id}`).then((res) => res.json());
};


export const deactivateUser = (userId) =>
{
    return fetch(_apiUrl + `/${userId}`,
        {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(userId)
        })
};

export const reactivateUser = (userId) =>
{
    return fetch(_apiUrl + `/${userId}`,
        {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(userId)
        })
};
