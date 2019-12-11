protected function encode_forge($list)
{
	if (!isset($list))
	{
		return $list;
	}
	if ($this->check_data($list, 'my_data'))
	{
		$res = base64_encode(gzcompress($list['my_data']));
		$list['my_data'] = $res;
	}

	return $list;
}