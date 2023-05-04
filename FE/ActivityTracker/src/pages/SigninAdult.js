import React from 'react';
import {SafeAreaView, View, Text} from 'react-native';
import {Button, TextInput} from 'react-native-paper';

function SigninAdult({navigation}) {
  return (
    <SafeAreaView>
      <View>
        <View>
          <Text>Username</Text>
          <TextInput />
        </View>
        <View>
          <Text>Password</Text>
          <TextInput />
        </View>
        <View>
          <Button
            mode="contained"
            style={{backgroundColor: 'gray'}}
            onPress={() => navigation.navigate('SignIn')}>
            Back
          </Button>
          <Button mode="contained" style={{backgroundColor: 'gray'}}>
            Sign In
          </Button>
        </View>
      </View>
    </SafeAreaView>
  );
}

export default SigninAdult;
