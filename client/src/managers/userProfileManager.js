const _apiUrl = "/api/userprofile";

export const getProfiles = () =>
{
  return fetch(_apiUrl + "/withroles").then((res) => res.json());
};

export const getProfile = (id) =>
{
  return fetch(_apiUrl + `/${id}`).then((res) => res.json());
};

export const promoteProfile = (id) =>
{
  return fetch(_apiUrl + `/promote/${id}`, { method: "POST" })
}

export const demoteProfile = (id) =>
{
  return fetch(_apiUrl + `/demote/${id}`, { method: "POST" })
}